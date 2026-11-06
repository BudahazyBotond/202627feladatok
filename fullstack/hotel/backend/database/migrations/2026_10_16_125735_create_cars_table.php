<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('cars', function (Blueprint $table) {
            $table->id();
            $table->foreignId("guest_id");
            $table->string("manufacturer",30);
            $table->string("model",30);
            $table->year("year");
            $table->string("color",30);
            $table->integer("price");
            $table->dateTime("from");
            $table->dateTime("to");
            $table->string("license_plate",12);
            $table->softDeletes();
            $table->foreign("guest_id")->references("id")->on("guests");
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('cars');
    }
};
