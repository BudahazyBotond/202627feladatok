<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class LessonSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {

        DB::table('lessons')->insert([
            // Laravel
            ['course_id' => 1, 'title' => 'Introduction to Laravel', 'duration' => 725],
            ['course_id' => 1, 'title' => 'Routing and Controllers', 'duration' => 1320],
            ['course_id' => 1, 'title' => 'Eloquent ORM', 'duration' => 1800],

            // React
            ['course_id' => 2, 'title' => 'React Fundamentals', 'duration' => 900],
            ['course_id' => 2, 'title' => 'Components and Props', 'duration' => 1500],
            ['course_id' => 2, 'title' => 'React Hooks', 'duration' => 2100],

            // Python
            ['course_id' => 3, 'title' => 'Getting Started with Python', 'duration' => 600],
            ['course_id' => 3, 'title' => 'Variables and Data Types', 'duration' => 1200],
            ['course_id' => 3, 'title' => 'Functions and Loops', 'duration' => 1560],

            // Vue
            ['course_id' => 4, 'title' => 'Vue Architecture', 'duration' => 1200],
            ['course_id' => 4, 'title' => 'Composition API', 'duration' => 1800],
            ['course_id' => 4, 'title' => 'State Management with Pinia', 'duration' => 2400],

            // SQL
            ['course_id' => 5, 'title' => 'Database Fundamentals', 'duration' => 840],
            ['course_id' => 5, 'title' => 'Writing SQL Queries', 'duration' => 1620],
            ['course_id' => 5, 'title' => 'Joins and Relationships', 'duration' => 1920],
        ]);
    }
}
