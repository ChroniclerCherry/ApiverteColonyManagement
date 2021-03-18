package com.example.apiverte_colony_management;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.List;

public class DeleteColonyPage extends AppCompatActivity {

    List<String> colSelectList = new ArrayList<>();

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_delete_colony);

        colSelectList.add("Select a Colony...");
        colSelectList.add("Test");

        //Create the colonySelect spinner
        ArrayAdapter<String> colSelectAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, colSelectList);
        colSelectAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner colSelectSpinner = findViewById(R.id.deleteSelectColonySpinner);
        colSelectSpinner.setAdapter(colSelectAdapter);

        Button submitButton = findViewById(R.id.deleteColonySubmitButton);
        submitButton.setOnClickListener(v -> {
            Intent refresh = getIntent();
            finish();
            startActivity(refresh);
            Toast.makeText(this, R.string.editColonyPageSubmitMessage, Toast.LENGTH_SHORT).show();
        });

        Button returnButton = findViewById(R.id.deleteColonyReturnButton);
        returnButton.setOnClickListener(v -> {
            finish();
        });
    }
}
