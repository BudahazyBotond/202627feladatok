<?php

namespace App\Http\Resources;

use Illuminate\Http\Request;
use Illuminate\Http\Resources\Json\JsonResource;
use Illuminate\Support\Facades\Storage;

class CourseResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @return array<string, mixed>
     */
    public function toArray(Request $request): array
    {
        return [
            "id" => $this->id,
            "image" => Storage::disk('public')->url("courses/{$this->image}"),
            "name" => $this->name,
            "level" => $this->level,
            "author" => $this->author,
            "price" => $this->price,
            "lessons" => LessonResource::collection($this->whenLoaded("lessons")),
        ];
    }
}
