package com.example.apiverte_colony_management.layout;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;

import java.util.List;

@Dao
public interface MyDao {

    @Insert
    public void addInspection(Inspection inspection);

    @Query("select * from inspections")
    public List<Inspection> getInspections();

}
