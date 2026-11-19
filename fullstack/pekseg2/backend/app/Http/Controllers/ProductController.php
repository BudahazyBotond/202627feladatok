<?php

namespace App\Http\Controllers;

use App\Models\Product;
use Illuminate\Http\Request;
use Illuminate\Http\Resources\Json\JsonResource;

class ProductController extends Controller
{
    public function index() : JsonResource{
        $data = Product::all();
        return $data->toResourceCollection();
    }
}
