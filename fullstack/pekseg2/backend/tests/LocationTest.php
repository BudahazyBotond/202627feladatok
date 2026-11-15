<?php

namespace Tests\Feature;

use App\Models\Location;
use Database\Factories\LocationFactory;
use Database\Seeders\LocationSeeder;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\SoftDeletes;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Foundation\Testing\WithFaker;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;
use Illuminate\Testing\Fluent\AssertableJson;
use PHPUnit\Framework\Attributes\DataProvider;
use Tests\TestCase;

class LocationTest extends TestCase
{
    use RefreshDatabase;

    private function validPayload(array $overrides = []): array
    {
        return array_merge([
            'address'      => 'Budapest, Fő utca 1.',
            'opening_time' => '06:00:00',
            'closing_time' => '19:00:00',
            'image'        => 'test.png',
        ], $overrides);
    }
    
    public function test_locations_table_id_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'id'), 'A locations tábla id mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'id'), 'integer', 'A locations tábla id mezője nem megfelelő típusú!');
        $this->assertEquals(collect(Schema::getIndexes('locations'))->firstWhere('name', 'primary')['columns'], ['id'], 'A locations tábla id mezője nem elsődleges kulcs!');
    }
    
    public function test_locations_table_name_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'address'), 'A locations tábla address mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'address'), 'varchar', 'A locations tábla address mezője nem megfelelő típusú!');
    }
    
    public function test_locations_table_opening_time_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'opening_time'), 'A locations tábla opening_time mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'opening_time'), 'time', 'A locations tábla opening_time mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'opening_time')['nullable'], 'A locations tábla opening_time mezője nem opcionális!');
    }
    
    public function test_locations_table_closing_time_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'closing_time'), 'A locations tábla closing_time mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'closing_time'), 'time', 'A locations tábla closing_time mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'closing_time')['nullable'], 'A locations tábla closing_time mezője nem opcionális!');
    }

    public function test_locations_table_image_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'image'), 'A locations tábla image mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'image'), 'varchar', 'A locations tábla image mezője nem megfelelő típusú!');
    }

    public function test_locations_table_timestamps_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'created_at'), 'A locations tábla created_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'created_at'), 'datetime', 'A locations tábla created_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'created_at')['nullable'], 'A locations tábla created_at mezője nem opcionális!');
        $this->assertTrue(Schema::hasColumn('locations', 'updated_at'), 'A locations tábla updated_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'updated_at'), 'datetime', 'A locations tábla updated_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'updated_at')['nullable'], 'A locations tábla updated_at mezője nem opcionális!');
    }

    public function test_locations_table_soft_deletes_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'deleted_at'), 'A locations tábla deleted_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'deleted_at'), 'datetime', 'A locations tábla deleted_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'deleted_at')['nullable'], 'A locations tábla deleted_at mezője nem opcionális!');
    }

    public function test_location_model_exists(): void 
    {
        $this->assertTrue(class_exists(Location::class), 'Nem létezik a Location modell!');
    }

    public function test_location_model_traits_correct(): void 
    {
        $this->assertContains(HasFactory::class, class_uses(Location::class), 'A HasFactory trait nem található a Location modellen!');
        $this->assertContains(SoftDeletes::class, class_uses(Location::class), 'A SoftDeletes trait nem található a Location modellen!');
    }

    public function test_location_factory_exists(): void {
        $this->assertTrue(class_exists(LocationFactory::class), 'Nem létezik a LocationFactory osztály!');
        $location = Location::factory()->create();
        $this->assertModelExists($location);
    }

    public function test_location_factory_address_correct(): void {
        $location = Location::factory()->create();
        $this->assertIsString($location->address, 'A LocationFactory által generált helyszín address mezője nem megfelelő típusú!');
        $this->assertStringContainsString(', ', $location->address, 'A LocationFactory által generált helyszín address mezője nem tartalmaz vesszőt és utána szóközt!');
        $this->assertStringEndsWith('.', $location->address, 'A LocationFactory által generált helyszín address mezője nem tartalmaz a végén pontot!');
    }

    public function test_location_factory_opening_time_correct(): void {
        $locations = Location::factory()->count(1000)->make()->pluck('opening_time')->all();
        $nullOpening = array_filter($locations, fn($x) => is_null($x));
        $notNullOpening = array_filter($locations, fn($x) => !is_null($x));
        $this->assertContainsOnlyNull($nullOpening, 'A LocationFactory által generált adatok nem tartalmaznak null értékű opening_time mezőket!');
        $this->assertContainsOnlyString($notNullOpening, 'A LocationFactory által generált adatok nem tartalmaznak megfelelő típusú opening_time mezőket!');
        $allowedHours = ['04:00:00', '05:00:00', '06:00:00', '07:00:00', '08:00:00', '09:00:00', '10:00:00'];
        $invalidTimes = array_filter($notNullOpening, fn($time) => !in_array($time, $allowedHours, true));
        $this->assertEmpty($invalidTimes, 'A LocationFactory által generált adatok nem kizárólag a kritériumoknak megfelelő opening_time mezőket tartalmaznak!');
    }

    public function test_location_factory_closing_time_correct(): void {
        $locations = Location::factory()->count(1000)->make()->pluck('closing_time')->all();
        $notNullClosing = array_filter($locations, fn($x) => !is_null($x));
        $this->assertContainsOnlyString($notNullClosing, 'A LocationFactory által generált adatok nem tartalmaznak megfelelő típusú closing_time mezőket!');
        $allowedHours = ['18:00:00', '19:00:00', '20:00:00', '21:00:00', '22:00:00'];
        $invalidTimes = array_filter($notNullClosing, fn($time) => !in_array($time, $allowedHours, true));
        $this->assertEmpty($invalidTimes, 'A LocationFactory által generált adatok nem kizárólag a kritériumoknak megfelelő closing_time mezőket tartalmaznak!');
        $locations = Location::factory()->count(1000)->make();
        $nullOpening = $locations->filter(fn($x) => is_null($x->opening_time))->pluck('closing_time')->all();
        $this->assertContainsOnlyNull($nullOpening, 'A LocationFactory által generált adatokban a closing_time nem null ott, ahol az opening_time null!');
    }

    public function test_location_factory_image_correct(): void {
        $location = Location::factory()->create();
        $this->assertModelExists($location);
        $this->assertIsString($location->image, 'A LocationFactory által generált helyszín image mezője nem megfelelő típusú!');
        $this->assertMatchesRegularExpression('/^(bakery-)([0-9])(.jpeg)$/', $location->image, 'A LocationFactory által generált helyszín image mezője nem megfelelő formátumú!');
    }

    public function test_location_seeder_correct(): void
    {
        $this->seed(LocationSeeder::class);
        $this->assertDatabaseCount('locations', 30);
    }

    public function test_making_a_get_request_to_locations_index(): void {
        $location = Location::factory()->create();
        Location::factory()->count(9)->create();
        $response = $this->getJson('/api/locations');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 10)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', $location->id)
                                ->where('address', $location->address)
                                ->where('opening_time', $location->opening_time)
                                ->where('closing_time', $location->closing_time)
                                ->where('image', env('APP_URL', 'http://backend.vm1.test') . "/images/locations/{$location->image}")
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_with_query_string_to_locations_index(): void {
        $location = Location::factory()->create(['address' => 'bécs']);
        Location::factory()->create(['address' => 'bécsújhely']);
        Location::factory()->count(9)->create();
        $response = $this->getJson('/api/locations?city=bécs');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 2)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', $location->id)
                                ->where('address', $location->address)
                                ->where('opening_time', $location->opening_time)
                                ->where('closing_time', $location->closing_time)
                                ->where('image', env('APP_URL', 'http://backend.vm1.test') . "/images/locations/{$location->image}")
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_to_locations_show(): void {
        $location = Location::factory()->create();
        $response = $this->getJson('/api/locations/' . $location->id);
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                                $json->where('id', $location->id)
                                    ->where('address', $location->address)
                                    ->where('opening_time', $location->opening_time)
                                    ->where('closing_time', $location->closing_time)
                                    ->where('image', env('APP_URL', 'http://backend.vm1.test') . "/images/locations/{$location->image}")
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_for_non_existent_model_to_locations_show(): void {
        $response = $this->getJson('/api/locations/1');
        $response->assertStatus(404);
    }

    public function test_making_a_post_request_to_locations_store(): void {
        $response = $this->postJson('/api/locations', $this->validPayload());
        $response->assertStatus(201)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                        $json->has('id')
                            ->where('address', 'Budapest, Fő utca 1.')
                            ->where('opening_time', '06:00:00')
                            ->where('closing_time', '19:00:00')
                            ->where('image', env('APP_URL', 'http://backend.vm1.test') . '/images/locations/test.png')
                            ->missing('created_at')
                            ->missing('updated_at')
                            ->missing('deleted_at')
                    )
            );
        $this->assertDatabaseHas('locations', [
            'address' => 'Budapest, Fő utca 1.', 'opening_time' => '06:00:00', 'closing_time' => '19:00:00',
        ]);
    }
 
    public function test_making_a_post_request_to_locations_store_without_times(): void {
        $payload = $this->validPayload();
        unset($payload['opening_time'], $payload['closing_time']);
        $this->postJson('/api/locations', $payload)->assertStatus(201);
        $this->assertDatabaseCount('locations', 1);
    }
 
    #[DataProvider('validBoundaryProvider')]
    public function test_locations_store_accepts_boundary_values(array $overrides): void {
        $this->postJson('/api/locations', $this->validPayload($overrides))->assertStatus(201);
    }
 
    #[DataProvider('invalidValueProvider')]
    public function test_locations_store_rejects_invalid_values(string $field, mixed $value): void {
        $response = $this->postJson('/api/locations', $this->validPayload([$field => $value]));
        $response->assertStatus(422)->assertJsonValidationErrors($field);
        $this->assertDatabaseCount('locations', 0);
    }
 
    #[DataProvider('requiredFieldProvider')]
    public function test_locations_store_rejects_missing_required_field(string $field): void {
        $payload = $this->validPayload();
        unset($payload[$field]);
        $this->postJson('/api/locations', $payload)
            ->assertStatus(422)
            ->assertJsonValidationErrors($field);
        $this->assertDatabaseCount('locations', 0);
    }
 
    public function test_locations_store_rejects_closing_time_without_opening_time(): void {
        $payload = $this->validPayload();
        unset($payload['opening_time']);
        $this->postJson('/api/locations', $payload)
            ->assertStatus(422)
            ->assertJsonValidationErrors('closing_time');
    }
 
    public function test_locations_store_rejects_null_opening_time_with_closing_time(): void {
        $this->postJson('/api/locations', $this->validPayload(['opening_time' => null]))
            ->assertStatus(422)
            ->assertJsonValidationErrors('closing_time');
    }
 
    public function test_locations_store_rejects_opening_time_without_closing_time(): void {
        $payload = $this->validPayload();
        unset($payload['closing_time']);
        $this->postJson('/api/locations', $payload)
            ->assertStatus(422)
            ->assertJsonValidationErrors('closing_time');
    }
 
    public function test_making_a_put_request_to_locations_update(): void {
        $location = Location::factory()->create();
        $response = $this->putJson('/api/locations/' . $location->id, $this->validPayload([
            'address' => 'Győr, Új utca 5.', 'opening_time' => '05:30:00', 'closing_time' => '18:30:00',
            'image' => 'new.png',
        ]));
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                        $json->where('id', $location->id)
                            ->where('address', 'Győr, Új utca 5.')
                            ->where('opening_time', '05:30:00')
                            ->where('closing_time', '18:30:00')
                            ->where('image', env('APP_URL', 'http://backend.vm1.test') . '/images/locations/new.png')
                    )
            );
        $this->assertDatabaseHas('locations', [
            'id' => $location->id, 'address' => 'Győr, Új utca 5.', 'image' => 'new.png',
        ]);
    }
 
    public function test_locations_update_overwrites_times_with_null(): void {
        $location = Location::factory()->create(['opening_time' => '06:00:00', 'closing_time' => '19:00:00']);
        $payload = $this->validPayload();
        unset($payload['opening_time'], $payload['closing_time']);
        $this->putJson('/api/locations/' . $location->id, $payload)->assertStatus(200);
        $this->assertDatabaseHas('locations', [
            'id' => $location->id, 'opening_time' => null, 'closing_time' => null,
        ]);
    }
 
    public function test_making_a_put_request_for_non_existent_model_to_locations_update(): void {
        $location = Location::factory()->create();
        $this->putJson('/api/locations/' . ($location->id + 1), $this->validPayload())
            ->assertStatus(404);
    }
 
    public function test_making_a_put_request_with_non_numeric_id_to_locations_update(): void {
        $this->putJson('/api/locations/abc', $this->validPayload())->assertStatus(404);
    }
 
    #[DataProvider('invalidValueProvider')]
    public function test_locations_update_rejects_invalid_values(string $field, mixed $value): void {
        $location = Location::factory()->create();
        $response = $this->putJson('/api/locations/' . $location->id, $this->validPayload([$field => $value]));
        $response->assertStatus(422)->assertJsonValidationErrors($field);
    }
 
    #[DataProvider('requiredFieldProvider')]
    public function test_locations_update_rejects_missing_required_field(string $field): void {
        $location = Location::factory()->create();
        $payload = $this->validPayload();
        unset($payload[$field]);
        $this->putJson('/api/locations/' . $location->id, $payload)
            ->assertStatus(422)
            ->assertJsonValidationErrors($field);
    }
 
    public function test_locations_update_rejects_closing_time_without_opening_time(): void {
        $location = Location::factory()->create();
        $payload = $this->validPayload();
        unset($payload['opening_time']);
        $this->putJson('/api/locations/' . $location->id, $payload)
            ->assertStatus(422)
            ->assertJsonValidationErrors('closing_time');
    }
 
    public function test_making_a_delete_request_to_locations_destroy(): void {
        $location = Location::factory()->create();
        $this->deleteJson('/api/locations/' . $location->id)->assertStatus(204);
        $this->assertSoftDeleted('locations', ['id' => $location->id]); // ha nincs SoftDeletes: assertDatabaseMissing
    }
 
    public function test_making_a_delete_request_for_non_existent_model_to_locations_destroy(): void {
        $location = Location::factory()->create();
        $this->deleteJson('/api/locations/' . ($location->id + 1))->assertStatus(404);
        $this->assertDatabaseCount('locations', 1);
    }
 
    public function test_making_a_delete_request_with_non_numeric_id_to_locations_destroy(): void {
        $this->deleteJson('/api/locations/abc')->assertStatus(404);
    }
 
    public function test_deleted_location_is_not_available_anymore(): void {
        $location = Location::factory()->create();
        $this->deleteJson('/api/locations/' . $location->id)->assertStatus(204);
        $this->getJson('/api/locations/' . $location->id)->assertStatus(404);
        $this->deleteJson('/api/locations/' . $location->id)->assertStatus(404);
    }
 
    public static function requiredFieldProvider(): array
    {
        return [
            'address' => ['address'],
            'image'   => ['image'],
        ];
    }
 
    public static function invalidValueProvider(): array
    {
        return [
            'address üres'                 => ['address', ''],
            'address túl hosszú'           => ['address', str_repeat('a', 201)],
            'opening_time rossz formátum'  => ['opening_time', '6:00'],
            'opening_time nem idő'         => ['opening_time', 'reggel'],
            'opening_time túl korai'       => ['opening_time', '03:59:59'],
            'opening_time túl késői'       => ['opening_time', '10:00:01'],
            'closing_time rossz formátum'  => ['closing_time', '19:00'],
            'closing_time nem idő'         => ['closing_time', 'este'],
            'closing_time túl korai'       => ['closing_time', '17:59:59'],
            'closing_time túl késői'       => ['closing_time', '22:00:01'],
            'image üres'                   => ['image', null],
            'image túl hosszú'             => ['image', str_repeat('a', 51)],
        ];
    }
 
    public static function validBoundaryProvider(): array
    {
        return [
            'address 200 karakter'  => [['address' => str_repeat('a', 200)]],
            'opening_time 04:00:00' => [['opening_time' => '04:00:00']],
            'opening_time 10:00:00' => [['opening_time' => '10:00:00']],
            'closing_time 18:00:00' => [['closing_time' => '18:00:00']],
            'closing_time 20:00:00' => [['closing_time' => '20:00:00']],
            'image 50 karakter'     => [['image' => str_repeat('a', 50)]],
        ];
    }
}
