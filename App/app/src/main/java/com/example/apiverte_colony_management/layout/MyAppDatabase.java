package com.example.apiverte_colony_management.layout;

import androidx.room.Dao;
import androidx.room.Database;
import androidx.room.RoomDatabase;

@Database(entities = {Inspection.class}, version = 1)
public abstract class MyAppDatabase extends RoomDatabase {


    public abstract MyDao myDao();
}
