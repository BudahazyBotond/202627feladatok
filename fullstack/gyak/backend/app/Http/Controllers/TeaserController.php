<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class TeaserController extends Controller
{
    function index(Request $request){
        $qb = DB::table("teasers");
        if($request->filled("section")){
            $qb->where("section",$request->query("section"))->orderBy("id","asc");
        }
        return ["data"=>$qb->get()];
    }
}
