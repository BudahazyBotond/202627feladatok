<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class HeroContentController extends Controller
{
    function index(){
        $qb = DB::table("hero_contents");
        return ["data"=>$qb->get()];
    }
}
