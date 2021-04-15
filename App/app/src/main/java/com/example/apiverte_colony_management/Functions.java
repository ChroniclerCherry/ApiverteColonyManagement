package com.example.apiverte_colony_management;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;

public class Functions extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_functions);

        Intent fromMain = getIntent();
        String user = fromMain.getStringExtra("USER");

        Button add_new_colony = findViewById(R.id.add_new_colony);
        add_new_colony.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToAddNewColony = new Intent(Functions.this, CreateColonyPage.class);
            goToAddNewColony.putExtra("USER", user);
            startActivity(goToAddNewColony);
        } });

        Button special_inspection = findViewById(R.id.special_inspection);
        special_inspection.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToSpecialInspection = new Intent(Functions.this, SpecialInspectionPage.class);
            goToSpecialInspection.putExtra("USER", user);
            startActivity(goToSpecialInspection);
        } });

        Button update = findViewById(R.id.update);
        update.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToUpdate = new Intent(Functions.this, UpdateWithServer.class);
            startActivity(goToUpdate);
        } });

    }
}