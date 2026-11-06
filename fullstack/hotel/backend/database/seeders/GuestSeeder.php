<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class GuestSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $unformatted = [
            "John Billionaire; 1985-04-12; true",
            "Emma Ellison; 1992-09-23; false",
            "Michael Zuckerberg; 1978-01-30; true",
            "Yi Long Ma; 1968-06-15; false"
        ];
        $formatted = [];
        foreach($unformatted as $line){
            $data = explode("; ",$line);
            $formattedData = [
                "name"=>$data[0],
                "date_of_birth"=>$data[1],
                "regular"=>($data[2]=="true")?true:false
            ];
            array_push($formatted,$formattedData);
        }
        DB::table("guests")->insert($formatted);
    }
}
