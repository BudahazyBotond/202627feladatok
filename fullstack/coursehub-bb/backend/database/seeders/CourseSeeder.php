<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class CourseSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        
        DB::table('courses')->insert([
            [
                'id' => 1,
                'image' => 'laravel-from scratch.png',
                'name' => 'Laravel From Scratch',
                'level' => 'beginner',
                'author' => 'John Smith',
                'price' => 49.99,
            ], 
            [
                'id' => 2,
                'image' => 'react-masterclass.png',
                'name' => 'React Masterclass',
                'level' => 'intermediate',
                'author' => 'Sarah Johnson',
                'price' => 79.99,
            ],
            [
                'id' => 3,
                'image' => 'python-for-beginners.png',
                'name' => 'Python for Beginners',
                'level' => 'beginner',
                'author' => 'Michael Brown',
                'price' => 39.99,
            ],
            [
                'id' => 4,
                'image' => 'advanced-vue.png',
                'name' => 'Advanced Vue.js',
                'level' => 'advanced',
                'author' => 'Emily Davis',
                'price' => 99.99,
            ],
            [
                'id' => 5,
                'image' => 'sql-and-database-design.png',
                'name' => 'SQL & Database Design',
                'level' => 'intermediate',
                'author' => 'David Wilson',
                'price' => 59.99,
            ],
        ]);
    }
}
