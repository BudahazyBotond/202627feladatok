<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class ProductsSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    /**
     *   id	name	price	unit	vat	image
     */
    public function run(): void
    {
        $data = "Kenyér 762.00	kg	0.18	bread.png,Csokoládés muffin	393.00	piece	0.27	chocolate-cupcake.png,Croissant	338.00	piece	0.18	croissant.png,Félbarna kenyér	677.00	kg	0.18	hard-dough-bread.png,Vizes zsemle	75.00	piece	0.18	hard-dough-roll.png,Hot dog kifli	126.00	piece	0.18	hot-dog-bun.png,Hosszúkás kifli	109.00	piece	0.18	long-hard-dough-roll.png,Mini fahéjas csiga	472.00	pack	0.27	mini-cinnamon-rolls.png,Pain au chocolat	393.00	piece	0.27	pain-au-chocolat.png,Zsemle	67.00	piece	0.18	roll.png,Szardíniás kenyér	550.00	piece	0.27	sardine-bread.png,Mázas fánk	393.00	piece	0.27	glazed-donut.png";
        $datas = explode(",",$data);
        $formatted = [];
        foreach($datas as $line){
            $fields = explode("\t",$line);
            $formattedData = [
                "name" => $fields[0],
                "price" => floatval($fields[1]),
                "unit" => $fields[2],
                "vat" => floatval($fields[3]),
                "image" => $fields[4]
            ];
            array_push($formatted,$formattedData);
        }
        DB::table("products")->insert($formatted);
    }
}
