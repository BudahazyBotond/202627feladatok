<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreCourseRequest;
use App\Http\Requests\UpdateCourseRequest;
use App\Http\Resources\CourseResource;
use App\Models\Course;

class CourseController extends Controller
{
    
    public function index()
    {
        $courses = Course::with("lessons")->get();
        return CourseResource::collection($courses);
    }


    public function show(Course $course)
    {
        return new CourseResource($course->load("lessons"));
    }

}
