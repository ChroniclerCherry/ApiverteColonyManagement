package com.example.apiverte_colony_management.DTOs;

import java.time.LocalDateTime;
import java.util.UUID;

public class ColonyDTO {
    public UUID Id;

    public String Name;

    public Boolean IsActive;

    public String CreatedBy;

    public LocalDateTime CreatedDate;
    public String LastModifiedBy;
    public LocalDateTime LastModifiedDate;

    public UUID HostId;

    public UUID AreaId;

    public int HiveNumber;

    public String ColonyNumber;
    public String ColonySource;
    public String QueenType;

    public String Markings;

    public String GeneticBreed;

    public String InstallationType;

    public String AdditionalInfo;

    public LocalDateTime InstallDate;

    public String HiveType;
    public String BroodChamberType;

    public Boolean QueenExclude;
}
