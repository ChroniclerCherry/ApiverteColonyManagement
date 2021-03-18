package com.example.apiverte_colony_management.layout;

import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "Typical Inspections")
public class Inspection {

    @PrimaryKey
    private int id;

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
