package com.example.apiverte_colony_management.layout;

import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "inspections")
public class Inspection {

    @PrimaryKey(autoGenerate = true)
    private int id = 0;

    private String population;
    private String mood;



    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getPopulation() {
        return population;
    }

    public void setPopulation(String population) {
        this.population = population;
    }

    public String getMood() {
        return mood;
    }

    public void setMood(String mood) {
        this.mood = mood;
    }
}
