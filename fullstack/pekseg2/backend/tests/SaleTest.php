<?php

namespace Tests\Feature;

use App\Models\Location;
use App\Models\Sale;
use Database\Factories\SaleFactory;
use Database\Seeders\SaleSeeder;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Foundation\Testing\WithFaker;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;
use Illuminate\Testing\Fluent\AssertableJson;
use PHPUnit\Framework\Attributes\DataProvider;
use Tests\TestCase;

class SaleTest extends TestCase
{
    use RefreshDatabase;

    private function validPayload(array $overrides = []): array
    {
        $locationId = Location::factory()->create()->id;
 
        return array_merge([
            'date'        => '2026-10-20',
            'location_id' => $locationId,
            'revenue'     => 15000.5,
        ], $overrides);
    }

    private function create_locations(): void {
        DB::table('locations')->insert([
            [ 'id' => 1, 'address' => '', 'image' => '' ],
            [ 'id' => 2, 'address' => '', 'image' => '' ],
            [ 'id' => 3, 'address' => '', 'image' => '' ],
            [ 'id' => 4, 'address' => '', 'image' => '' ],
            [ 'id' => 5, 'address' => '', 'image' => '' ],
        ]);
    }

    public function test_sales_table_id_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('sales', 'id'), 'A sales tábla id mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('sales', 'id'), 'integer', 'A sales tábla id mezője nem megfelelő típusú!');
        $this->assertEquals(collect(Schema::getIndexes('sales'))->firstWhere('name', 'primary')['columns'], ['id'], 'A locations tábla id mezője nem elsődleges kulcs!');
    }

    public function test_sales_table_date_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('sales', 'date'), 'A sales tábla date mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('sales', 'date'), 'date', 'A sales tábla date mezője nem megfelelő típusú!');
    }

    public function test_sales_table_location_id_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('sales', 'location_id'), 'A sales tábla location_id mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('sales', 'location_id'), 'integer', 'A sales tábla location_id mezője nem megfelelő típusú!');
        $fk = Schema::getForeignKeys('sales')[0];
        $this->assertEquals($fk['columns'][0], 'location_id', 'A sales tábla location_id mezőjének idegen kulcs megszorítása nem megfelelő!');
        $this->assertEquals($fk['foreign_table'], 'locations', 'A sales tábla location_id mezőjének idegen kulcs megszorítása nem megfelelő!');
        $this->assertEquals($fk['foreign_columns'][0], 'id', 'A sales tábla location_id mezőjének idegen kulcs megszorítása nem megfelelő!');
    }

    public function test_sales_table_revenue_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('sales', 'revenue'), 'A sales tábla revenue mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('sales', 'revenue'), 'numeric', 'A sales tábla revenue mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('sales'))->firstWhere('name', 'revenue')['nullable'], 'A sales tábla revenue mezője nem opcionális!');
    }

    public function test_sale_model_exists(): void 
    {
        $this->assertTrue(class_exists(Sale::class), 'Nem létezik a Sale modell!');
    }

    public function test_sale_model_traits_correct(): void 
    {
        $this->assertContains(HasFactory::class, class_uses(Sale::class), 'A HasFactory trait nem található a Sale modellen!');
    }

    public function test_sale_factory_exists(): void {
        $this->assertTrue(class_exists(SaleFactory::class), 'Nem létezik a SaleFactory osztály!');
        $this->create_locations();
        $sale = Sale::factory()->create();
        $this->assertModelExists($sale);
    }

    public function test_sale_factory_date_correct(): void {
        $this->create_locations();
        $sales = Sale::factory()->count(1000)->make()->pluck('date')->all();
        $incorrect = array_filter($sales, fn($x) => !preg_match('/^2026\-((10\-(1[0-9]|2[0-9]|3[01]))|(11\-0[1-5]))$/', $x));
        $this->assertEmpty($incorrect, 'A SaleFactory által generál eladásoknál van olyan, ahol nem megfelelő a date mező!');
    }

    public function test_sale_factory_location_id_correct(): void {
        $this->create_locations();
        $locations = Sale::factory()->count(20)->make()->unique('location_id')->pluck('location_id')->all();
        foreach ($locations as $id) $this->assertDatabaseHas('locations', ['id' => $id]);
    }

    public function test_sale_factory_revenue_correct(): void {
        $this->create_locations();
        $sales = Sale::factory()->count(1000)->make()->pluck('revenue')->all();
        $incorrect = array_filter($sales, fn($x) => $x < 30000 || $x > 50000);
        $this->assertEmpty($incorrect, 'A SaleFactory által generál eladásoknál van olyan, ahol nem megfelelő a revenue mező!');
    }

    public function test_sale_seeder_correct(): void
    {
        $this->create_locations();
        $this->seed(SaleSeeder::class);
        $this->assertDatabaseCount('sales', 250);
        $this->assertDatabaseHas('sales', ['revenue' => null]);
    }

    public function test_making_a_get_request_to_sales_index(): void {
        $this->create_locations();
        $sale = Sale::factory()->create();
        Sale::factory()->count(9)->create();
        $response = $this->getJson('/api/sales');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 10)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', $sale->id)
                                ->where('date', $sale->date)
                                ->where('location_id', $sale->location_id)
                                ->where('revenue', $sale->revenue)
                        )
            );
    }

    public function test_making_a_get_request_to_sales_show(): void {
        $this->create_locations();
        $sale = Sale::factory()->create();
        $response = $this->getJson('/api/sales/' . $sale->id);
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                        $json->where('id', $sale->id)
                            ->where('date', $sale->date)
                            ->where('location_id', $sale->location_id)
                            ->where('revenue', $sale->revenue)
                    )
            );
    }

    public function test_making_a_get_request_for_non_existent_model_to_sales_show(): void {
        $response = $this->getJson('/api/sales/1');
        $response->assertStatus(404);
    }

    public function test_making_a_get_request_to_sales_sum(): void {
        $this->create_locations();
        $sum = Sale::factory()->count(10)->create()->sum('revenue');
        $response = $this->getJson('/api/sales/sum');
        $response->assertStatus(200)
            ->assertJson([ 'data' => $sum ]);
    }

    public function test_making_a_get_request_with_query_string_to_sales_sum(): void {
        $this->create_locations();
        Sale::factory()->count(10)->create();
        DB::table('locations')->insert([[ 'id' => 67, 'address' => '', 'image' => '' ],]);
        $sum = Sale::factory()->count(10)->create([ 'date' => '2026-11-06', 'location_id' => 67, ])->sum('revenue');
        $response1 = $this->getJson('/api/sales/sum?date=2026-11-06');
        $response1->assertStatus(200)
            ->assertJson([ 'data' => $sum ]);
        $response2 = $this->getJson('/api/sales/sum?location_id=67');
        $response2->assertStatus(200)
            ->assertJson([ 'data' => $sum ]);
        $response3 = $this->getJson('/api/sales/sum?date=2026-11-06&location_id=67');
        $response3->assertStatus(200)
            ->assertJson([ 'data' => $sum ]);
    }

    public function test_making_a_post_request_to_sales_store(): void {
        $payload = $this->validPayload();
        $response = $this->postJson('/api/sales', $payload);
        $response->assertStatus(201)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                        $json->has('id')
                            ->where('date', $payload['date'])
                            ->where('location_id', $payload['location_id'])
                            ->where('revenue', $payload['revenue'])
                    )
            );
        $this->assertDatabaseHas('sales', [
            'date' => $payload['date'], 'location_id' => $payload['location_id'],
        ]);
    }
 
    public function test_making_a_post_request_to_sales_store_without_optional_revenue(): void {
        $payload = $this->validPayload();
        unset($payload['revenue']);
        $this->postJson('/api/sales', $payload)->assertStatus(201);
        $this->assertDatabaseCount('sales', 1);
    }
 
    #[DataProvider('validBoundaryProvider')]
    public function test_sales_store_accepts_boundary_values(array $overrides): void {
        $this->postJson('/api/sales', $this->validPayload($overrides))->assertStatus(201);
    }
 
    #[DataProvider('invalidValueProvider')]
    public function test_sales_store_rejects_invalid_values(string $field, mixed $value): void {
        $response = $this->postJson('/api/sales', $this->validPayload([$field => $value]));
        $response->assertStatus(422)->assertJsonValidationErrors($field);
        $this->assertDatabaseCount('sales', 0);
    }
 
    #[DataProvider('requiredFieldProvider')]
    public function test_sales_store_rejects_missing_required_field(string $field): void {
        $payload = $this->validPayload();
        unset($payload[$field]);
        $this->postJson('/api/sales', $payload)
            ->assertStatus(422)
            ->assertJsonValidationErrors($field);
        $this->assertDatabaseCount('sales', 0);
    }
 
    public function test_sales_store_rejects_non_existent_location(): void {
        $location = Location::factory()->create();
        $response = $this->postJson('/api/sales', [
            'date' => '2026-10-20', 'location_id' => $location->id + 1, 'revenue' => 100,
        ]);
        $response->assertStatus(422)->assertJsonValidationErrors('location_id');
        $this->assertDatabaseCount('sales', 0);
    }
 
    public function test_sales_store_rejects_deleted_location(): void {
        $location = Location::factory()->create();
        $payload = ['date' => '2026-10-20', 'location_id' => $location->id, 'revenue' => 100];
        $location->delete();
        // Soft delete esetén a rekord még a táblában van, így ez a teszt csak akkor releváns,
        // ha az implementáció figyelembe veszi a törölt állapotot; egyébként törölhető.
        $this->postJson('/api/sales', $payload)->assertStatus(201);
    }
 
    public function test_sales_has_no_update_or_destroy_route(): void {
        $location = Location::factory()->create();
        $sale = Sale::factory()->create(['location_id' => $location->id, 'date' => '2026-10-20']);
        $this->putJson('/api/sales/' . $sale->id, [])->assertStatus(405);
        $this->deleteJson('/api/sales/' . $sale->id)->assertStatus(405);
    }
 
    public function test_making_a_get_request_to_sales_sum_without_sales(): void {
        $this->getJson('/api/sales/sum')
            ->assertStatus(200)
            ->assertJson(['data' => 0]);
    }
 
    public function test_sales_sum_with_non_matching_date_returns_zero(): void {
        $location = Location::factory()->create();
        Sale::factory()->count(3)->create(['location_id' => $location->id, 'date' => '2026-10-20']);
        $this->getJson('/api/sales/sum?date=2026-11-01')
            ->assertStatus(200)
            ->assertJson(['data' => 0]);
    }
 
    public function test_sales_sum_with_non_matching_location_returns_zero(): void {
        $location = Location::factory()->create();
        Sale::factory()->count(3)->create(['location_id' => $location->id, 'date' => '2026-10-20']);
        $this->getJson('/api/sales/sum?location_id=' . ($location->id + 1))
            ->assertStatus(200)
            ->assertJson(['data' => 0]);
    }
 
    public function test_sales_sum_with_combined_filter_excludes_other_sales(): void {
        $locationA = Location::factory()->create();
        $locationB = Location::factory()->create();
        Sale::factory()->create(['location_id' => $locationA->id, 'date' => '2026-10-20', 'revenue' => 1000]);
        Sale::factory()->create(['location_id' => $locationA->id, 'date' => '2026-10-21', 'revenue' => 2000]);
        Sale::factory()->create(['location_id' => $locationB->id, 'date' => '2026-10-20', 'revenue' => 4000]);
 
        $this->getJson("/api/sales/sum?date=2026-10-20&location_id={$locationA->id}")
            ->assertStatus(200)->assertJson(['data' => 1000]);
        $this->getJson('/api/sales/sum?date=2026-10-20')
            ->assertStatus(200)->assertJson(['data' => 5000]);
        $this->getJson("/api/sales/sum?location_id={$locationA->id}")
            ->assertStatus(200)->assertJson(['data' => 3000]);
        $this->getJson('/api/sales/sum')
            ->assertStatus(200)->assertJson(['data' => 7000]);
    }
 
 
    public static function requiredFieldProvider(): array
    {
        return [
            'date'        => ['date'],
            'location_id' => ['location_id'],
        ];
    }
 
    public static function invalidValueProvider(): array
    {
        return [
            'date üres'                => ['date', null],
            'date nem dátum'           => ['date', 'tegnap'],
            'date rossz formátum'      => ['date', '20/10/2026'],
            'date pontokkal'           => ['date', '2026.10.20'],
            'date túl korai'           => ['date', '2026-10-09'],
            'date túl késői'           => ['date', '2026-11-06'],
            'date más évben'           => ['date', '2025-10-20'],
            'location_id üres'         => ['location_id', null],
            'location_id nem szám'     => ['location_id', 'abc'],
            'location_id nem létezik'  => ['location_id', 999999],
            'revenue nem szám'         => ['revenue', 'abc'],
            'revenue negatív'          => ['revenue', -0.01],
        ];
    }
 
    public static function validBoundaryProvider(): array
    {
        return [
            'date első nap'   => [['date' => '2026-10-10']],
            'date utolsó nap' => [['date' => '2026-11-05']],
            'revenue 0'       => [['revenue' => 0]],
            'revenue tört'    => [['revenue' => 123.45]],
        ];
    }
}
