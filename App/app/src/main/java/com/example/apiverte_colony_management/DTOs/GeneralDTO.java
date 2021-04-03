package com.example.apiverte_colony_management.DTOs;

import java.time.LocalDateTime;
import java.util.UUID;

public class GeneralDTO {
    public UUID Id;

    public String Name;

    public Boolean IsActive;

    public String CreatedBy;

    public LocalDateTime CreatedDate;
    public String LastModifiedBy;
    public LocalDateTime LastModifiedDate;
}
