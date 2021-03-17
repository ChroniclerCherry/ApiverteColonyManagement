package com.example.apiverte_colony_management;

import androidx.room.*;

@Dao
public interface ColonyDataDAO {

    @Query("SELECT * FROM ColonyData WHERE Id = (:Id)")
    ColonyData findById(int Id);

    @Insert
    void insert(ColonyData... colonyData);

}
