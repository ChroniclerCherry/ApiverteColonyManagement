package com.example.apiverte_colony_management.room_db;

import androidx.room.Entity;
import androidx.room.PrimaryKey;

import org.jetbrains.annotations.NotNull;

import java.util.UUID;

@Entity(tableName = "inspections")
public class Inspection {

    @PrimaryKey
    @NotNull
    private UUID id;


    private String[] weather;
    private String population;
    private String mood;
    private String fitness;
    private int broodChamber;
    private int honeyChamber;
    private boolean mouseGuard;
    private boolean pollenCollector;
    private String hiveBottom;
    private String vents;
    private String brood;
    private String honey;
    private String[] issue;
    private String[] growth;
    private String[] seasonal;
    private String status;
    private String cells;
    private String swarmStatus;
    private boolean excluder;


    //private Date date;

    public Inspection() {

        this.id = UUID.randomUUID();
    }

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
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

    public String[] getWeather() {
        return weather;
    }

    public void setWeather(String[] weather) {
        this.weather = weather;
    }

    public String getFitness() {
        return fitness;
    }

    public void setFitness(String fitness) {
        this.fitness = fitness;
    }

    public int getBroodChamber() {
        return broodChamber;
    }

    public void setBroodChamber(int broodChamber) {
        this.broodChamber = broodChamber;
    }

    public int getHoneyChamber() {
        return honeyChamber;
    }

    public void setHoneyChamber(int honeyChamber) {
        this.honeyChamber = honeyChamber;
    }

    public boolean isMouseGuard() {
        return mouseGuard;
    }

    public void setMouseGuard(boolean mouseGuard) {
        this.mouseGuard = mouseGuard;
    }

    public boolean isPollenCollector() {
        return pollenCollector;
    }

    public void setPollenCollector(boolean pollenCollector) {
        this.pollenCollector = pollenCollector;
    }

    public String getHiveBottom() {
        return hiveBottom;
    }

    public void setHiveBottom(String hiveBottom) {
        this.hiveBottom = hiveBottom;
    }

    public String getVents() {
        return vents;
    }

    public void setVents(String vents) {
        this.vents = vents;
    }

    public String getBrood() {
        return brood;
    }

    public void setBrood(String brood) {
        this.brood = brood;
    }

    public String getHoney() {
        return honey;
    }

    public void setHoney(String honey) {
        this.honey = honey;
    }

    public String[] getIssue() {
        return issue;
    }

    public void setIssue(String[] issue) {
        this.issue = issue;
    }

    public String[] getGrowth() {
        return growth;
    }

    public void setGrowth(String[] growth) {
        this.growth = growth;
    }

    public String[] getSeasonal() {
        return seasonal;
    }

    public void setSeasonal(String[] seasonal) {
        this.seasonal = seasonal;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getCells() {
        return cells;
    }

    public void setCells(String cells) {
        this.cells = cells;
    }

    public String getSwarmStatus() {
        return swarmStatus;
    }

    public void setSwarmStatus(String swarmStatus) {
        this.swarmStatus = swarmStatus;
    }

    public boolean isExcluder() {
        return excluder;
    }

    public void setExcluder(boolean excluder) {
        this.excluder = excluder;
    }
}
