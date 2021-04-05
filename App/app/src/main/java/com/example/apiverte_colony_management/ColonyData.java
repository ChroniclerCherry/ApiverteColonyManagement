package com.example.apiverte_colony_management;

import androidx.room.*;
import java.sql.Timestamp;

@Entity
public class ColonyData {
    @PrimaryKey
    int Id;
    @ColumnInfo(name = "CreatedBy")
    String colCreatedBy;
    @ColumnInfo(name = "CreatedDate")
    Timestamp colCreatedDate;
    @ColumnInfo(name = "LastModifiedBy")
    String colLastModifiedBy;
    @ColumnInfo(name = "LastModifiedDate")
    Timestamp colLastModifiedDate;
    @ColumnInfo(name = "IsActive")
    Boolean colIsActive;
    @ColumnInfo(name = "HostId")
    int colHost;
    @ColumnInfo(name = "AreaId")
    int colArea;
    @ColumnInfo(name = "HiveNumber")
    int colHiveNum;
    @ColumnInfo(name = "ColonyNumber")
    String colColonyNum;
    @ColumnInfo(name = "ColonySource")
    String colSource;
    @ColumnInfo(name = "QueenType")
    String colQueen;
    @ColumnInfo(name = "Markings")
    String colMarkings;
    @ColumnInfo(name = "GeneticBreed")
    String colGenetics;
    @ColumnInfo(name = "InstallationType")
    String colInstallType;
    @ColumnInfo(name = "AdditionalInfo")
    String colAddInfo;
    @ColumnInfo(name = "InstallDate")
    Timestamp colInstallDate;
    @ColumnInfo(name = "HiveType")
    String colHiveType;
    @ColumnInfo(name = "BroodChamberType")
    String colBroodChamber;
    @ColumnInfo(name = "QueenExclude")
    Boolean colQueenExcluder;

    ColonyData(){

    }

}
