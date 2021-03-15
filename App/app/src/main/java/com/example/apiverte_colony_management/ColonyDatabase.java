package com.example.apiverte_colony_management;

import androidx.room.RoomDatabase;

public abstract class ColonyDatabase extends RoomDatabase {
    public abstract ColonyDataDAO colonyDataDAO();
}
