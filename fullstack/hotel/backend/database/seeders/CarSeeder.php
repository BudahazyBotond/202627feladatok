<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class CarSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $unformatted = [
            "2; BMW; M4; 2024; Blue; 110000; 2026-10-13 08:00:00; 2026-10-15 20:00:00; CD-EF-202",
            "1; Mercedes-Benz; S 500; 2023; Black; 95000; 2026-10-10 10:00:00; 2026-10-12 18:00:00; AA-BB-101",
            "4; Tesla; Cybertruck; 2026; Black; 99990; 2026-10-20 12:00:00; 2026-10-22 12:00:00; KL-MN-404",
            "3; Porsche; 911 Carrera; 2022; Red; 145000; 2026-10-16 09:00:00; 2026-10-18 17:00:00; GH-IJ-303"
        ];
        $formatted = [];
        foreach($unformatted as $line){
            $data = explode("; ",$line);
            $formattedData = [
                "guest_id"=>$data[0],
                "manufacturer"=>$data[1],
                "model"=>$data[2],
                "year"=>$data[3],
                "color"=>$data[4],
                "price"=>$data[5],
                "from"=>$data[6],
                "to"=>$data[7],
                "license_plate"=>$data[8]
            ];
            array_push($formatted,$formattedData);
        }
        DB::table("cars")->insert($formatted);
    }
}
