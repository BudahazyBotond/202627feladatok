<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class HelicopterSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $unformatted = [
            "4; Robinson; R44; 2019; Red; 4; 240; 560; 210000; false; 2026-10-21 10:00:00; 2026-10-21 17:00:00",
            "2; Bell; 429; 2023; White; 7; 278; 761; 480000; true; 2026-10-14 09:00:00; 2026-10-14 18:00:00",
            "3; Leonardo; AW109; 2020; Grey; 7; 311; 932; 520000; true; 2026-10-17 07:00:00; 2026-10-17 16:00:00",
            "1; Airbus; H125; 2021; Black; 6; 287; 630; 350000; false; 2026-10-11 08:00:00; 2026-10-11 15:00:00"
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
                "passenger_capacity"=>$data[5],
                "max_velocity"=>$data[6],
                "range"=>$data[7],
                "twin_engine"=>$data[8],
                "price"=>$data[9],
                "from"=>$data[10],
                "to"=>$data[11],
            ];
            array_push($formatted,$formattedData);
        }
        DB::table("yachts")->insert($formatted);
    }
}
