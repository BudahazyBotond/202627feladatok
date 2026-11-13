<?php

namespace Database\Seeders;

use App\Models\Product;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class ProductSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $datas = [
            "id;name;price;unit;vat;image",
            "1;Kenyér;762.00;kg;0.18;bread.png",
            "2;Csokoládés muffin;393.00;piece;0.27;chocolate-cupcake.png",
            "3;Croissant;338.00;piece;0.18;croissant.png",
            "4;Félbarna kenyér;677.00;kg;0.18;hard-dough-bread.png",
            "5;Vizes zsemle;75.00;piece;0.18;hard-dough-roll.png",
            "6;Hot dog kifli;126.00;piece;0.18;hot-dog-bun.png",
            "7;Hosszúkás kifli;109.00;piece;0.18;long-hard-dough-roll.png",
            "8;Mini fahéjas csiga;472.00;pack;0.27;mini-cinnamon-rolls.png",
            "9;Pain au chocolat;393.00;piece;0.27;pain-au-chocolat.png",
            "10;Zsemle;67.00;piece;0.18;roll.png",
            "11;Szardíniás kenyér;550.00;piece;0.27;sardine-bread.png",
            "12;Mázas fánk;393.00;piece;0.27;glazed-donut.png"
        ];
        $formatted = [];
        foreach($datas as $line){
            $fields = explode(";",$line);
            $formattedData = [
                "name" => $fields[0],
                "price" => floatval($fields[1]),
                "unit" => $fields[2],
                "vat" => floatval($fields[3]),
                "image" => $fields[4]
            ];
            array_push($formatted,$formattedData);
        }
        Product::query("products")->insert($formatted);
    }
}
