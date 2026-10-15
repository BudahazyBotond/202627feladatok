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

    function planner(Request $req, string $from, string $to){
        $qb = DB::table("trains");
        $qb->where("origin","like",$from)->where("destination","like",$to);
        if($req->filled("time")){
            if($req->filled("time-type")){
                $qb->where($req->query("time-type")."_time", $req->query("time-type") == "arrival" ? ">" : "<", $req->query("time"));
            }
            else{
                $qb->where("arrival_time", ">", $req->query("time"));
            }
        }
        $qb->orderBy("is_overnight","asc")->orderBy("arrival_time","asc")->orderBy("departure_time","desc")->orderBy("second_class_price", "asc");
        return ["data"=>$qb->get()];
    }
}
