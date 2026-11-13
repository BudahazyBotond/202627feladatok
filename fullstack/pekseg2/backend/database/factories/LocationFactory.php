<?php

namespace Database\Factories;

use App\Models\Location;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends Factory<Location>
 */
class LocationFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        $opening = fake()->optional(0.1)->numberBetween(4,10);
        return [
            "adress" => fake()->city() . ", " . fake()->streetName() . " utca " . fake()->numberBetween(1,100),
            "opening_time" => $opening === null ? $opening . ":00" : null,
            "closing_time" => $opening === null ? fake()->numberBetween(18,22) . ":00" : null,
            "image" => "location-" . fake()->numberBetween() . ".jpeg"
        ];
    }
}
