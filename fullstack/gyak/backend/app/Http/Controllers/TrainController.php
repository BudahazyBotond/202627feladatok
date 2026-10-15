<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class TrainController extends Controller
{
    function show(int $train){
        $qb = DB::table("trains");
        $qb->where("id",$train);
        return ["data" => $qb->first()];
    }
}
