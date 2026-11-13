<?php

use App\Http\Controllers\LocationController;
use App\Http\Controllers\ProductController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get("/products",[ProductController::class,"index"])
->name("products.index");

Route::get("/locations",[LocationController::class,"index"])
->name("locations.index");

Route::get("/products/{id}",[ProductController::class,"show"])
->whereNumber("id")
->name("products.show");

Route::get("/locations/{id}",[LocationController::class,"show"])
->whereNumber("id")
->name("locations.show");
