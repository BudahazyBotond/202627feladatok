<?php

use App\Http\Controllers\ProductController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');
Route::get("/products",[ProductController::class,"index"])
->name("products.index");

Route::get("/products/{id}",[ProductController::class,"index"])
->whereNumber("id")
->name("products.show");


Route::get("/locations/{id}",[ProductController::class,"index"])
->whereNumber("id")
->name("locations.show");
