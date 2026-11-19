<?php

namespace Database\Factories;

use App\Models\Location;
use App\Models\Sale;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends Factory<Sale>
 */
class SaleFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        $loc_ids = Location::pluck("id");
        return [
            "date" => fake()->dateTimeBetween("2026-10-10","2026-11-5")->format("Y-m-d"),
            "location_id" => fake()->randomElement($loc_ids),
            "revenue" => fake()->numberBetween(30000,50000)
        ];
    }
}
