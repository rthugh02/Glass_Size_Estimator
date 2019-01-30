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

### Operations

All types of operations that will be utilized in the logic for all product lines

| Operation | Description |
|-----------|-------------|
| float SetValue(float value) | Set the current value in the pipeline to the given value |
| enum SetValue(enum value) | Set the current value in the pipeline to the given value |
| bool SetValue(bool value) | Set the current value in the pipeline to the given value |
| float Addition(float value) | Add the given value to the current value in the pipeline |
| float Subtraction(float value) | Subtract the given value from the current value in the pipeline |
| float Multiplication(float value) | Multiply the given value by the current value in the pipeline |
| float Division(float value) | Divide the given value to the desired value by the current value in the pipeline |
| float RoundUp(List<> StockListing) | Round up the current value in the pipeline to the next available size in the given stock listing |
| float RoundDown(List<> StockListing) | Round down the current value in the pipeline to the next available size in the given stock listing |
| float RoundUp(Enum Cutoff) | Round up the current value in the pipeline to the next available cutoff (i.e. Next 1/2" or next whole number) |
| float RoundDown(Enum Cutoff) | Round down the current value in the pipeline to the next available cutoff (i.e. Next 1/2" or next whole number) |
| void Branch(int nextStep) | Branch to another path |
| void BranchBoolean(string booleanName, bool qualifier, int nextStep) | Branch to another path if the current boolean in the pipeline is true/false in the list |
| void BranchSeries(List<> Series, bool qualifier, int nextStep) | Branch to another path if the current series in the pipeline is included/not included in the list |
| void BranchConfiguration(List<> Configuration, bool qualifier, int nextStep) | Branch to another path if the current configuration in the pipeline is included/not included in the list |
| void BranchValue(float minimum, float maximum, bool qualifier, int nextStep) | Branch to another path if the current value in the pipeline is included /not included within the given range (inclusive) |
| float Truncate() | Truncate the current value in the pipeline |
| bool CheckStockListing(List<> StockListing) | Return whether or not the current value is available in the given stock listing |
| void End() | Signals the end of the logic and flags the current value in the pipeline to be final

### UI Generation

All types and their corresponding UI element

| Type | Corresponding Element |
|------|-----------------------|
| FLOAT | Text Area |
| INT | Text Area |
| ENUM | Dropdown List |
| BOOLEAN | Checkbox |
| COORDINATE | Text Area |

### Example JSON CONFIGURATION

```
{
  "Product Line": "Stock Cardinal Series Semi-frameless Single Doors",
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
        "Operation": "BranchValue",
        "Minimum": 0,
        "Maximum": 0.125,
        "NextStep": 3,
        "Qualifier": true
      },
      {
        "Operation": "BranchValue",
        "Minimum": 0.1875,
        "Maximum": 0.6875,
        "NextStep": 5,
        "Qualifier": true
      },
      {
        "Operation": "BranchValue",
        "Minimum": 0.75,
        "Maximum": 1,
        "NextStep": 7,
        "Qualifier": true
      },
      {
        "Operation": "RoundDown",
        "Cutoff": "Whole"
      },
      {
        "Operation": "Branch",
        "NextStep": 9
      },
      {
        "Operation": "Truncate"
      },
      {
        "Operation": "Branch",
        "NextStep": 9
      },
      {
        "Operation": "RoundUp",
        "Cutoff": "Whole"
      },
      {
        "Operation": "Branch",
        "NextStep": 9
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
        "Operation": "BranchBoolean",
        "BooleanName": "Clear Sweep",
        "Qualifier": false,
        "NextStep": 3
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
        "Operation": "BranchValue",
        "Minimum": 0,
        "Maximum": 0.125,
        "NextStep": 3,
        "Qualifier": true
      },
      {
        "Operation": "BranchValue",
        "Minimum": 0.1875,
        "Maximum": 0.6875,
        "NextStep": 5,
        "Qualifier": true
      },
      {
        "Operation": "BranchValue",
        "Minimum": 0.75,
        "Maximum": 1,
        "NextStep": 3,
        "Qualifier": true
      },
      {
        "Operation": "SetValue",
        "Value": "ZD1028"
      },
      {
        "Operation": "Branch",
        "NextStep": 7
      },
      {
        "Operation": "SetValue",
        "Value": "ZD1006"
      },
      {
        "Operation": "Branch",
        "NextStep": 7
      },
      {
        "Operation": "End"
      }
    ]
  }
}
```
