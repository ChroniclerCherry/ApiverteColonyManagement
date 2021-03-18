package com.example.apiverte_colony_management.layout;

import androidx.room.Dao;
import androidx.room.Insert;

@Dao
public interface MyDao {

    @Insert
    public void addInspection(Inspection inspection);

}
