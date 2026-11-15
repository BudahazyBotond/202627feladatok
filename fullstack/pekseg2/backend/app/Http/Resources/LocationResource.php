<?php

namespace App\Http\Resources;

use Illuminate\Http\Request;
use Illuminate\Http\Resources\Json\JsonResource;

class LocationResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @return array<string, mixed>
     */
    public function toArray(Request $request): array
    {
        return [
            "adress" => $this->adress,
            "opening_time" => $this->opening_time,
            "closing_time" => $this->closing_time,
            "image" => $this->image
        ];
    }
}
