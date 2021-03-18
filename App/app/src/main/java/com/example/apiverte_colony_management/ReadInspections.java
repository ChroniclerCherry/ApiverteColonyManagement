package com.example.apiverte_colony_management;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.apiverte_colony_management.layout.Inspection;

import java.util.List;


public class ReadInspections extends AppCompatActivity {

private TextView displayInspection;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fragment_read_inspections);

        displayInspection = findViewById(R.id.displayinspection);
        List<Inspection> inspections = TypicalInspection.myAppDatabase.myDao().getInspections();

        String info = "";

        for ( Inspection i : inspections) {

            int id = i.getId();
            String population = i.getPopulation();
            String mood = i.getMood();

            info = info + " \n\n" + "id :"+id+"\n population :"+population+"\n mood :"+mood;
        }

        displayInspection.setText(info);
    }
}