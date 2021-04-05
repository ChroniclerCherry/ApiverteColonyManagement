package com.example.apiverte_colony_management.layout;

import android.content.Context;

import androidx.room.Dao;
import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;
import androidx.room.TypeConverter;
import androidx.room.TypeConverters;

import java.util.Date;
import java.util.UUID;

@Database(entities = {Inspection.class}, version = 1)
@TypeConverters({UUIDConverter.class, DateConverter.class})
public abstract class MyAppDatabase extends RoomDatabase {

    private static MyAppDatabase INSTANCE;
    private static final String DATABASE_NAME = "InspectionDatabase";

    public abstract MyDao myDao();

    public static void init(Context context) {
        if (INSTANCE == null) {
            INSTANCE = Room.databaseBuilder(context.getApplicationContext(), MyAppDatabase.class, DATABASE_NAME).build();
        }
    }

    public static MyAppDatabase getINSTANCE() {
        if (INSTANCE == null) throw new IllegalStateException("init in MyApplication.class");
        return INSTANCE;
    }
}

class UUIDConverter {

    @TypeConverter
    public static String fromUUID(UUID uuid) {
        return uuid.toString();
    }

    @TypeConverter
    public static UUID uuidFromString(String string) {
        return UUID.fromString(string);
    }
}

class DateConverter {

    @TypeConverter
    public static long timestampFromDate(Date date) {
        return date.getTime();
    }

    @TypeConverter
    public static Date dateFromTimestamp(long timestamp) {
        return new Date(timestamp);
    }
}