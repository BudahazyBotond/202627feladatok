<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class TimetableController extends Controller
{
    function origins(){
        $qb = DB::table("trains");
        $qb->distinct("origin")->orderBy("origin","asc");
        return ["data"=>$qb->pluck("origin")];
    }

    function destinations(Request $request){
        $qb = DB::table("trains");
        if($request->filled("origin")){
            $qb->where("origin",$request->query("origin"));
        }
        $qb->distinct("destination")->orderBy("destination","asc");
        return ["data"=>$qb->pluck("destination")];
    }
}
