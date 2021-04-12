package com.example.apiverte_colony_management;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class UsersMyOpener extends SQLiteOpenHelper {

    protected final static String DATABASE_NAME = "UsersDB";

    protected final static int VERSION_NUM = 1;

    public final static String TABLE_NAME = "USERS";

    public final static String COL_ID = "_id";

    public final static String COL_NAME = "USERNAME";

    public final static String COL_CREATEDBY = "CREATEDBY";

    public final static String COL_CREATEDDATE = "CREATEDDATE";

    public final static String COL_LASTMODIFIEDBY = "LASTMODIFIEDBY";

    public final static String COL_LASTMODIFIEDDATE = "LASTMODIFIEDDATE";

    public final static String COL_ISACTIVE = "ISACTIVE";

    public UsersMyOpener(Context ctx)
    {
        super(ctx, DATABASE_NAME, null, VERSION_NUM);
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {

        db.execSQL("CREATE TABLE " + TABLE_NAME + " (_id INTEGER PRIMARY KEY AUTOINCREMENT, "
                + COL_NAME + " text,"
                + COL_CREATEDBY + " text,"
                + COL_CREATEDDATE + " text,"
                + COL_LASTMODIFIEDBY + " text,"
                + COL_LASTMODIFIEDDATE + " text,"
                + COL_ISACTIVE  + " text);");

//        db.execSQL("INSERT INTO " + TABLE_NAME + " (_id, USERNAME)" +
//                " VALUES (1, 'Oliver Smith');");
//
//        db.execSQL("INSERT INTO " + TABLE_NAME + " (_id, USERNAME)" +
//                " VALUES (2, 'Jack Williams');");
//
//        db.execSQL("INSERT INTO " + TABLE_NAME + " (_id, USERNAME)" +
//                " VALUES (3, 'Elizabeth Brown');");
//
//        db.execSQL("INSERT INTO " + TABLE_NAME + " (_id, USERNAME)" +
//                " VALUES (4, 'Barbara Murphy');");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {   //Drop the old table:
        db.execSQL( "DROP TABLE IF EXISTS " + TABLE_NAME);

        //Create the new table:
        onCreate(db);
    }

    @Override
    public void onDowngrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {   //Drop the old table:
        db.execSQL( "DROP TABLE IF EXISTS " + TABLE_NAME);

        //Create the new table:
        onCreate(db);
    }

    public int getVersion() { return VERSION_NUM; }
}
