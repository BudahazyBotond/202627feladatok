<?php

namespace App\Http\Controllers;

use App\Models\Location;
use Illuminate\Http\Request;
use Illuminate\Http\Resources\Json\JsonResource;

class LocationController extends Controller
{
    public function index() : JsonResource{
        $data = Location::all();
        return $data->toResourceCollection();
    }
}
