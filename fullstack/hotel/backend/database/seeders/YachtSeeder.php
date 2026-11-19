<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class YachtSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $unformatted = [
            "3; Azimut; Grande 27; false; 2024; White; 980000; 2026-10-20 09:00:00; 2026-10-24 20:00:00; Royal Wave",
            "1; Sunseeker; Predator 74; false; 2022; White; 750000; 2026-10-10 12:00:00; 2026-10-14 12:00:00; Ocean Dream",
            "4; Jeanneau; Sun Odyssey 440; true; 2020; White; 390000; 2026-10-25 08:00:00; 2026-10-28 18:00:00; Sea Breeze",
            "2; Beneteau; Oceanis 46; true; 2021; Blue; 420000; 2026-10-15 10:00:00; 2026-10-19 18:00:00; Blue Horizon"            
        ];
        $formatted = [];
        foreach($unformatted as $line){
            $data = explode("; ",$line);
            $formattedData = [
                "guest_id"=>$data[0],
                "manufacturer"=>$data[1],
                "model"=>$data[2],
                "sailing"=>($data[3]=="true")?true:false,
                "year"=>$data[4],
                "color"=>$data[5],
                "price"=>$data[6],
                "from"=>$data[7],
                "to"=>$data[8],
                "name"=>$data[9],
            ];
            array_push($formatted,$formattedData);
        }
        DB::table("yachts")->insert($formatted);
    }
}
