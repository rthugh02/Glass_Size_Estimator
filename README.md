# Configuration File

### Input

All types of inputs that will be utilized between all of the product lines

| Name | Type | Description |
|------|------|-------------|
| Opening Width | FLOAT | Width measurement in inches |
| Opening Height | FLOAT | Height measurement in inches |
| Series | ENUM | Customer requested series: <br> {ATE, ASE, ETE, ESE, HATE, HASE, HGTE, HGSE, LETE, LESE, PTE, PSE, PTETE, PTESE, PRETE, PRESE, SE, TE, TTE, TSE, TETE, TESE} |
| Towel Bar | ENUM | Customer requested towel bar: <br> {18", 24"} |
| Finger Pull | ENUM | Customer requested finger pull: <br> {STANDARD, RECESSED} |
| Clear Sweep | BOOLEAN | Customer requested for clear sweep |
| Configuration | ENUM | Customer requested configuration (Names not official): <br> {ONE INLINE PANEL, TWO INLINE PANEL, TWO PARTIAL INLINE PANEL, 90 DEGREE RETURN PANEL, 135 DEGREE RETURN PANEL, NOTCHED INLINE PANEL, NEO PANEL}
| Item Number | INT | Customer requested item number |

### Output

All types of output that will be calculated between all of the product lines

| Name | Type | Description |
|------|------|-------------|
| Resulting Width | FLOAT | Resulting width after calculations |
| Resulting Height | FLOAT | Resulting height after calcuations |
| In Stock | BOOLEAN | Whether or not the resulting dimensions are available in a stock piece |
| Hole Placement | COORDINATE[] | A list of locations of holes (x,y) to be placed |
| Hole Size | FLOAT | The size of holes to be placed |
| Wall Jamb | ENUM | Resulting wall jamb piece to be used: <br> {ZD1028, ZD1006} |

### Stock Glass Lines

A separate configuration file is used to store all measurements of stock glass for each product line.

When defining a product line, the user must also define which lines of stock glass it should compare its resulting measurements with. Once the glass size estimations are completed, a seperate checkbox will be used to indicate whether a stock piece can be used instead.

### States

All states of operations that will be utilized in the logic for all product lines

| States | Description |
|--------|-------------|
| float SetValue(float value) | Set the current value in the pipeline to the given value |
| float SetEnum(string value, string category) | Set the current value in the pipeline to the given value |
| float SetConditional(bool value) | Set the current value in the pipeline to the given value |
| float Addition(float value) | Add the given value to the current value in the pipeline |
| float Subtraction(float value) | Subtract the given value from the current value in the pipeline |
| float Multiplication(float value) | Multiply the given value by the current value in the pipeline |
| float Division(float value) | Divide the given value to the desired value by the current value in the pipeline |
| float RoundUp(Float Interval) | Round up the current value in the pipeline to the next available cutoff (i.e. Next 1/2" or next whole number) |
| float RoundDown(Float Interval) | Round down the current value in the pipeline to the next available cutoff (i.e. Next 1/2" or next whole number) |
| void Branch(int nextStep) | Branch to another path |
| void BranchConditional(string ConditionalName, bool qualifier, int nextStep) | Branch to another path if the current boolean in the pipeline is true/false in the list |
| void BranchSeries(String[] Series, bool qualifier, int nextStep) | Branch to another path if the current series in the pipeline is included/not included in the list |
| void BranchConfiguration(String[] Configuration, bool qualifier, int nextStep) | Branch to another path if the current configuration in the pipeline is included/not included in the list |
| void BranchValue(float minimum, float maximum, bool qualifier, int nextStep) | Branch to another path if the current value in the pipeline is included /not included within the given range (inclusive) |
| void BranchFractionalValue(float minimum, float maximum, bool qualifier, int nextStep) | Branch to another path if the current value's fractional value in the pipeline is included /not included within the given range (inclusive) |
| float Truncate() | Truncate the current value in the pipeline |
| void End() | Signals the end of the logic and flags the current value in the pipeline to be final

### UI Generation

All types and their corresponding UI element

| Type | Corresponding Element |
|------|-----------------------|
| FLOAT | Text Area |
| INT | Text Area |
| ENUM | Dropdown List (input) / Text Area (output) |
| BOOLEAN | Checkbox |
| COORDINATE | Text Area |

### Example PRODUCT LINE JSON CONFIGURATION

```
{
  "ProductLines": [
    {
      "Name": "Stock Cardinal Series Semi-frameless Single Doors",
      "Input": [
        "OpeningWidth",
        "OpeningHeight",
        "ClearSweep"
      ],
      "Output": [
        "ResultingWidth",
        "ResultingHeight",
        "WallJamb"
      ],
      "Logic": {
        "ResultingWidth": [
          {
            "Operation": "BranchFractionalValue",
            "Minimum": 0,
            "Maximum": 0.125,
            "NextState": 3,
            "Qualifier": true
          },
          {
            "Operation": "BranchFractionalValue",
            "Minimum": 0.1875,
            "Maximum": 0.6875,
            "NextState": 5,
            "Qualifier": true
          },
          {
            "Operation": "BranchFractionalValue",
            "Minimum": 0.75,
            "Maximum": 1,
            "NextState": 7,
            "Qualifier": true
          },
          {
            "Operation": "RoundDown",
            "Interval": 1
          },
          {
            "Operation": "Branch",
            "NextState": 9
          },
          {
            "Operation": "Truncate"
          },
          {
            "Operation": "Branch",
            "NextState": 9
          },
          {
            "Operation": "RoundUp",
            "Interval": 1
          },
          {
            "Operation": "Branch",
            "NextState": 9
          },
          {
            "Operation": "Subtraction",
            "Value": 4
          },
          {
            "Operation": "Addition",
            "Value": 0.8125
          },
          {
            "Operation": "End"
          }
        ],
        "ResultingHeight": [
          {
            "Operation": "Subtraction",
            "Value": 1.625
          },
          {
            "Operation": "BranchConditional",
            "ConditionalName": "ClearSweep",
            "Qualifier": false,
            "NextState": 3
          },
          {
            "Operation": "Addition",
            "Value": 0.75
          },
          {
            "Operation": "End"
          }
        ],
        "WallJamb": [
          {
            "Operation": "BranchFractionalValue",
            "Minimum": 0,
            "Maximum": 0.125,
            "NextState": 3,
            "Qualifier": true
          },
          {
            "Operation": "BranchFractionalValue",
            "Minimum": 0.1875,
            "Maximum": 0.6875,
            "NextState": 5,
            "Qualifier": true
          },
          {
            "Operation": "BranchFractionalValue",
            "Minimum": 0.75,
            "Maximum": 1,
            "NextState": 3,
            "Qualifier": true
          },
          {
            "Operation": "SetEnum",
            "Value": "ZD1028",
            "Category": "WallJamb"
          },
          {
            "Operation": "Branch",
            "NextState": 7
          },
          {
            "Operation": "SetEnum",
            "Value": "ZD1006",
            "Category": "WallJamb"
          },
          {
            "Operation": "Branch",
            "NextState": 7
          },
          {
            "Operation": "End"
          }
        ]
      },
      "StockGlassLine": [
        "Door_Glass_69_Stall_3/16_Clear",
        "Door_Glass_69_Stall_3/16_Rain",
        "Door_Glass_69_Stall_3/16_P5",
        "Door_Glass_72_Stall_3/16_Clear",
        "Door_Glass_72_Stall_3/16_Rain",
        "Door_Glass_72_Stall_3/16_P5",
        "Door_Glass_75_Stall_3/16_Clear",
        "Door_Glass_75_Stall_3/16_Rain",
        "Door_Glass_75_Stall_3/16_P5"
      ]
    }
  ]
}
```

### Example STOCK GLASS LINE JSON Configuration

```
"Door_Glass_69_Stall_3/16_Clear": [
    {
      "Width": 18.8125,
      "Height": 65
    },
    {
      "Width": 19.8125,
      "Height": 65
    },
    {
      "Width": 20.8125,
      "Height": 65
    },
    {
      "Width": 21.8125,
      "Height": 65
    },
    {
      "Width": 22.8125,
      "Height": 65
    },
    {
      "Width": 23.8125,
      "Height": 65
    },
    {
      "Width": 24.8125,
      "Height": 65
    },
    {
      "Width": 25.8125,
      "Height": 65
    },
    {
      "Width": 26.8125,
      "Height": 65
    },
    {
      "Width": 27.8125,
      "Height": 65
    },
    {
      "Width": 28.8125,
      "Height": 65
    },
    {
      "Width": 29.8125,
      "Height": 65
    },
    {
      "Width": 30.8125,
      "Height": 65
    },
    {
      "Width": 31.8125,
      "Height": 65
    },
    {
      "Width": 32.8125,
      "Height": 65
    }
  ]
```