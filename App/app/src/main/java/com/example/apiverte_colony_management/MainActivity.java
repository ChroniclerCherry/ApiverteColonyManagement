package com.example.apiverte_colony_management;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity implements AdapterView.OnItemSelectedListener {

    ArrayList<Users> usersList = new ArrayList<>();

    static SQLiteDatabase db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        loadDataFromDatabase();
        String[] users = new String[usersList.size()];
        int i = 0;
        for(Users element: usersList) {
            users[i] = element.getUserName();
            i++;
        }

        Spinner spin = findViewById(R.id.spinner);
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, R.layout.spinner_item, users);
        spin.setAdapter(adapter);
        spin.setOnItemSelectedListener(this);

        Button sign_in = findViewById(R.id.sign_in);
        sign_in.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToFunctions = new Intent(MainActivity.this, Functions.class);
            startActivity(goToFunctions);
        } });

        Button manage_users = findViewById(R.id.manage_users);
        manage_users.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToManageUsers = new Intent(MainActivity.this, ManageUsers.class);
            startActivity(goToManageUsers);
        } });
    }

    private void loadDataFromDatabase()
    {
        usersList.clear();
        //get a database connection:
        UsersMyOpener dbOpener = new UsersMyOpener(this);
        db = dbOpener.getWritableDatabase();

        // We want to get all of the columns. Look at UsersMyOpener.java for the definitions:
        String [] columns = {UsersMyOpener.COL_ID, UsersMyOpener.COL_NAME};
        //query all the results from the database:
        Cursor results = db.query(false, UsersMyOpener.TABLE_NAME, columns, null, null, null, null, null, null);

        //Now the results object has rows of results that match the query.
        //find the column indices:
        int idColIndex = results.getColumnIndex(UsersMyOpener.COL_ID);
        int nameColumnIndex = results.getColumnIndex(UsersMyOpener.COL_NAME);

        //iterate over the results, return true if there is a next item:
        while(results.moveToNext())
        {
            long id = results.getLong(idColIndex);
            String name = results.getString(nameColumnIndex);

            //add the new Contact to the array list:
            usersList.add(new Users(id, name));
        }

        if(usersList.size() == 0) {
            usersList.add(new Users(0, "No user in the database"));
        }
        //At this point, the usersList array has loaded every row from the cursor.
    }

    @Override
    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {

    }

    @Override
    public void onNothingSelected(AdapterView<?> adapterView) {

    }

    @Override
    public void onResume() {
        super.onResume();
        loadDataFromDatabase();
        String[] users = new String[usersList.size()];
        int i = 0;
        for(Users element: usersList) {
            users[i] = element.getUserName();
            i++;
        }

        Spinner spin = findViewById(R.id.spinner);
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, R.layout.spinner_item, users);
        spin.setAdapter(adapter);
    }

    @Override
    public void onRestart() {
        super.onRestart();
        loadDataFromDatabase();
        String[] users = new String[usersList.size()];
        int i = 0;
        for(Users element: usersList) {
            users[i] = element.getUserName();
            i++;
        }

        Spinner spin = findViewById(R.id.spinner);
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, R.layout.spinner_item, users);
        spin.setAdapter(adapter);
    }
}