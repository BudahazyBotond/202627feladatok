<?php

namespace Tests\Feature;

use App\Models\Product;
use Database\Seeders\ProductSeeder;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\SoftDeletes;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Foundation\Testing\WithFaker;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;
use Illuminate\Testing\Fluent\AssertableJson;
use PHPUnit\Framework\Attributes\DataProvider;
use Tests\TestCase;

class ProductTest extends TestCase
{
    use RefreshDatabase;

    private function validPayload(array $overrides = []): array
    {
        return array_merge([
            'name'  => 'Teszt kenyér',
            'price' => 1200,
            'unit'  => 'kg',
            'vat'   => 0.27,
            'image' => 'test.png',
        ], $overrides);
    }

    private function createProduct(array $overrides = []): Product
    {
        return Product::create($this->validPayload($overrides));
    }

    public function test_products_table_id_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'id'), 'A products tábla id mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'id'), 'integer', 'A products tábla id mezője nem megfelelő típusú!');
        $this->assertEquals(collect(Schema::getIndexes('products'))->firstWhere('name', 'primary')['columns'], ['id'], 'A products tábla id mezője nem elsődleges kulcs!');
    }
    
    public function test_products_table_name_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'name'), 'A products tábla name mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'name'), 'varchar', 'A products tábla name mezője nem megfelelő típusú!');
    }
    
    public function test_products_table_price_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'price'), 'A products tábla price mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'price'), 'numeric', 'A products tábla price mezője nem megfelelő típusú!');
    }
    
    public function test_products_table_unit_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'unit'), 'A products tábla unit mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'unit'), 'varchar', 'A products tábla unit mezője nem megfelelő típusú!');
        $this->assertStringContainsString("check (\"unit\" in ('piece', 'kg', 'gram', 'pack', 'slice'))", DB::selectOne("SELECT sql FROM sqlite_master WHERE type='table' AND name='products'")->sql, 'A products tábla unit mezője nem csak a megadott értékeket veheti fel!');
    }

    public function test_products_table_vat_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'vat'), 'A products tábla vat mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'vat'), 'numeric', 'A products tábla vat mezője nem megfelelő típusú!');
        $this->assertEquals(collect(Schema::getColumns('products'))->firstWhere('name', 'vat')['default'], "'0.27'", 'A products tábla vat mezőjének alapértelmezett értéke nem megfelelő!');
    }

    public function test_products_table_image_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'image'), 'A products tábla image mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'image'), 'varchar', 'A products tábla image mezője nem megfelelő típusú!');
    }

    public function test_products_table_timestamps_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'created_at'), 'A products tábla created_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'created_at'), 'datetime', 'A products tábla created_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('products'))->firstWhere('name', 'created_at')['nullable'], 'A products tábla created_at mezője nem opcionális!');
        $this->assertTrue(Schema::hasColumn('products', 'updated_at'), 'A products tábla updated_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'updated_at'), 'datetime', 'A products tábla updated_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('products'))->firstWhere('name', 'updated_at')['nullable'], 'A products tábla updated_at mezője nem opcionális!');
    }

    public function test_products_table_soft_deletes_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'deleted_at'), 'A products tábla deleted_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'deleted_at'), 'datetime', 'A products tábla deleted_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('products'))->firstWhere('name', 'deleted_at')['nullable'], 'A products tábla deleted_at mezője nem opcionális!');
    }

    public function test_product_seeder_correct(): void
    {
        $this->seed(ProductSeeder::class);
        $this->assertDatabaseCount('products', 12);
    }

    public function test_product_model_exists(): void 
    {
        $this->assertTrue(class_exists(Product::class), 'Nem létezik a Product modell!');
    }

    public function test_product_model_traits_correct(): void 
    {
        $this->assertContains(SoftDeletes::class, class_uses(Product::class), 'A SoftDeletes trait nem található a Product modellen!');
    }

    public function test_product_model_full_price_attribute_correct(): void {
        $data = [ 'price' => 1, 'vat' => 0.50, ];
        $product = new Product();
        $product->price = $data['price'];
        $product->vat = $data['vat'];
        $this->assertEquals($product->fullPrice, round($data['price'] + ($data['price'] * $data['vat'])), 'A Product modell fullPrice attribútuma nem megfelelő!');
    }

    public function test_making_a_get_request_to_products_index(): void {
        $this->seed();
        $response = $this->getJson('/api/products');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 12)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', 1)
                                ->where('name', 'Kenyér')
                                ->where('price', 899)
                                ->where('unit', 'kg')
                                ->where('image', 'http://backend.vm1.test/images/products/bread.png')
                                ->missing('vat')
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_with_query_string_to_products_index(): void {
        $this->seed();
        $response = $this->getJson('/api/products?name=zsemle');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 2)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', 5)
                                ->where('name', 'Vizes zsemle')
                                ->where('price', 89)
                                ->where('unit', 'piece')
                                ->where('image', 'http://backend.vm1.test/images/products/hard-dough-roll.png')
                                ->missing('vat')
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_to_products_show(): void {
        $this->seed();
        $response = $this->getJson('/api/products/1');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                            $json->where('id', 1)
                                ->where('name', 'Kenyér')
                                ->where('price', 899)
                                ->where('unit', 'kg')
                                ->where('image', 'http://backend.vm1.test/images/products/bread.png')
                                ->missing('vat')
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_for_non_existent_model_to_products_show(): void {
        $response = $this->getJson('/api/products/1');
        $response->assertStatus(404);
    }

    public function test_making_a_post_request_to_products_store(): void {
        $response = $this->postJson('/api/products', $this->validPayload());
        $response->assertStatus(201)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                        $json->has('id')
                            ->where('name', 'Teszt kenyér')
                            ->has('price')
                            ->where('unit', 'kg')
                            ->where('image', env('APP_URL', 'http://backend.vm1.test') . '/images/products/test.png')
                            ->missing('vat')
                            ->missing('created_at')
                            ->missing('updated_at')
                            ->missing('deleted_at')
                    )
            );
        $this->assertDatabaseHas('products', [
            'name' => 'Teszt kenyér', 'unit' => 'kg', 'image' => 'test.png',
        ]);
    }

    public function test_making_a_post_request_to_products_store_without_optional_vat(): void {
        $payload = $this->validPayload();
        unset($payload['vat']);
        $this->postJson('/api/products', $payload)->assertStatus(201);
        $this->assertDatabaseCount('products', 1);
    }
 
    #[DataProvider('validBoundaryProvider')]
    public function test_products_store_accepts_boundary_values(array $overrides): void {
        $this->postJson('/api/products', $this->validPayload($overrides))->assertStatus(201);
    }
 
    #[DataProvider('invalidValueProvider')]
    public function test_products_store_rejects_invalid_values(string $field, mixed $value): void {
        $response = $this->postJson('/api/products', $this->validPayload([$field => $value]));
        $response->assertStatus(422)->assertJsonValidationErrors($field);
        $this->assertDatabaseCount('products', 0);
    }
 
    #[DataProvider('requiredFieldProvider')]
    public function test_products_store_rejects_missing_required_field(string $field): void {
        $payload = $this->validPayload();
        unset($payload[$field]);
        $response = $this->postJson('/api/products', $payload);
        $response->assertStatus(422)->assertJsonValidationErrors($field);
        $this->assertDatabaseCount('products', 0);
    }

    public function test_making_a_put_request_to_products_update(): void {
        $product = $this->createproduct();
        $response = $this->putJson('/api/products/' . $product->id, $this->validPayload([
            'name' => 'Módosított név', 'unit' => 'piece', 'image' => 'new.png',
        ]));
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                        $json->where('id', $product->id)
                            ->where('name', 'Módosított név')
                            ->has('price')
                            ->where('unit', 'piece')
                            ->where('image', env('APP_URL', 'http://backend.vm1.test') . '/images/products/new.png')
                            ->missing('vat')
                    )
            );
        $this->assertDatabaseHas('products', [
            'id' => $product->id, 'name' => 'Módosított név', 'unit' => 'piece', 'image' => 'new.png',
        ]);
    }
 
    public function test_making_a_put_request_for_non_existent_model_to_products_update(): void {
        $product = $this->createproduct();
        $this->putJson('/api/products/' . ($product->id + 1), $this->validPayload())
            ->assertStatus(404);
    }
 
    public function test_making_a_put_request_with_non_numeric_id_to_products_update(): void {
        $this->putJson('/api/products/abc', $this->validPayload())->assertStatus(404);
    }
 
    #[DataProvider('invalidValueProvider')]
    public function test_products_update_rejects_invalid_values(string $field, mixed $value): void {
        $product = $this->createproduct();
        $response = $this->putJson('/api/products/' . $product->id, $this->validPayload([$field => $value]));
        $response->assertStatus(422)->assertJsonValidationErrors($field);
        $this->assertDatabaseMissing('products', ['id' => $product->id, $field => $value]);
    }
 
    #[DataProvider('requiredFieldProvider')]
    public function test_products_update_rejects_missing_required_field(string $field): void {
        $product = $this->createproduct();
        $payload = $this->validPayload();
        unset($payload[$field]);
        $this->putJson('/api/products/' . $product->id, $payload)
            ->assertStatus(422)
            ->assertJsonValidationErrors($field);
    }
 
    public function test_making_a_delete_request_to_products_destroy(): void {
        $product = $this->createproduct();
        $this->deleteJson('/api/products/' . $product->id)->assertStatus(204);
        $this->assertSoftDeleted('products', ['id' => $product->id]); // ha nincs SoftDeletes: assertDatabaseMissing
    }
 
    public function test_making_a_delete_request_for_non_existent_model_to_products_destroy(): void {
        $product = $this->createproduct();
        $this->deleteJson('/api/products/' . ($product->id + 1))->assertStatus(404);
        $this->assertDatabaseCount('products', 1);
    }
 
    public function test_making_a_delete_request_with_non_numeric_id_to_products_destroy(): void {
        $this->deleteJson('/api/products/abc')->assertStatus(404);
    }
 
    public function test_deleted_product_is_not_available_anymore(): void {
        $product = $this->createproduct();
        $this->deleteJson('/api/products/' . $product->id)->assertStatus(204);
        $this->getJson('/api/products/' . $product->id)->assertStatus(404);
        $this->deleteJson('/api/products/' . $product->id)->assertStatus(404);
    }


    public static function requiredFieldProvider(): array
    {
        return [
            'name'  => ['name'],
            'price' => ['price'],
            'unit'  => ['unit'],
            'image' => ['image'],
        ];
    }
 
    public static function invalidValueProvider(): array
    {
        return [
            'name üres'            => ['name', ''],
            'name túl hosszú'      => ['name', str_repeat('a', 31)],
            'name nem szöveg'      => ['name', ['tömb']],
            'price üres'           => ['price', null],
            'price nem szám'       => ['price', 'abc'],
            'price negatív'        => ['price', -1],
            'unit üres'            => ['unit', null],
            'unit érvénytelen'     => ['unit', 'nemletezoegyseg'],
            'vat nem szám'         => ['vat', 'abc'],
            'vat negatív'          => ['vat', -0.01],
            'vat nagyobb mint 1'   => ['vat', 1.01],
            'image üres'           => ['image', null],
            'image túl hosszú'     => ['image', str_repeat('a', 51)],
        ];
    }
 
    public static function validBoundaryProvider(): array
    {
        return [
            'name 30 karakter'  => [['name' => str_repeat('a', 30)]],
            'price 0'           => [['price' => 0]],
            'price tört'        => [['price' => 99.5]],
            'unit piece'        => [['unit' => 'piece']],
            'vat 0'             => [['vat' => 0]],
            'vat 1'             => [['vat' => 1]],
            'image 50 karakter' => [['image' => str_repeat('a', 50)]],
        ];
    }
}
