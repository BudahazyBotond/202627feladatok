<?php

namespace App\Http\Controllers;

use Illuminate\Database\Query\Builder;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class ProductController extends Controller
{
    public function index() {
        $products = DB::table('products')
            ->get();

        return response()->json(['data' => $products]);
    }

    public function show(int $id) {
        $product = DB::table('products')
            ->where('id', $id)
            ->firstOrFail();

        return response()->json(['data' => $product]);
    }

    public function cheaps() {
        $products = DB::table('products')
            ->orderBy('price')
            ->get();

        return response()->json(['data' => $products]);
    }

    public function discounted(Request $request) {
        $category = $request->query('category');

        $products = DB::table('products')
            ->when($category, function(Builder $query, string $category) {
                return $query->where('category', $category);
            })
            ->whereNotNull('discount')
            ->get();

        return response()->json(['data' => $products]);
    }

    public function sum() {
        $sum = DB::table('products')
            ->sum('price');

        return response()->json(['data' => $sum]);
    }

    public function recommended() {
        $products = DB::table('products')
            ->whereNotNull('discount')
            ->where('price', '<', 20)
            ->pluck('name', 'id');

        return response()->json(['data' => $products]);
    }
}
