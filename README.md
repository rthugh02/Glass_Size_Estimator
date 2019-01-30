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
| float Addition(float value) | Add the given value to the current value in the pipeline |
| float Subtraction(float value) | Subtract the given value from the current value in the pipeline |
| float Multiplication(float value) | Multiply the given value by the current value in the pipeline |
| float Division(float value) | Divide the given value to the desired value by the current value in the pipeline |
| float RoundUp(List<> StockListing) | Round up the current value in the pipeline to the next available size in the given stock listing |
| float RoundDown(List<> StockListing) | Round down the current value in the pipeline to the next available size in the given stock listing |
| float RoundUp(Enum Cutoff) | Round up the current value in the pipeline to the next available cutoff (i.e. Next 1/2" or next whole number) |
| float RoundDown(Enum Cutoff) | Round down the current value in the pipeline to the next available cutoff (i.e. Next 1/2" or next whole number) |
| void BranchSeries(List<> Series) | Branch to another path if the current series in the pipeline is included in the list |
| void BranchConfiguration(List<> Configuration) | Branch to another path if the current configuration in the pipeline is included in the list |
| void BranchValue(float min, float max) | Branch to another path if the current value in the pipeline is included within the given range (inclusive) |
| float DropFraction() | Truncate the current value in the pipeline |
| bool CheckStockListing(List<> StockListing) | Return whether or not the current value is available in the given stock listing |

### UI Generation

All types and their corresponding UI element

| Type | Corresponding Element |
|------|-----------------------|
| FLOAT | Text Area |
| INT | Text Area |
| ENUM | Dropdown List |
| BOOLEAN | Checkbox |
| COORDINATE | Text Area |
