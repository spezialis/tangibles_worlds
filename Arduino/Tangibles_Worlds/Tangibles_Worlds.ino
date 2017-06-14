// Distance sensor
const int distPin0 = A0;
const int distPin1 = A1;
const int distPin2 = A2;

int distPin0Val;
int distPin1Val;
int distPin2Val;

// Flex sensor
const int flexPin3 = A3;
const int flexPin4 = A4;
const int flexPin5 = A5;
const int flexPin6 = A6;

int flexPin3Val;
int flexPin4Val;
int flexPin5Val;
int flexPin6Val;

// Photocell
const int photoPin7 = A7;
const int photoPin8 = A8;
const int photoPin9 = A9;
const int photoPin10 = A10;

int photoPin7Val;
int photoPin8Val;
int photoPin9Val;
int photoPin10Val;

void setup() {
  Serial.begin(9600);
}

void loop() {
  // Dist
  distPin0Val = analogRead(distPin0);
  distPin1Val = analogRead(distPin1);
  distPin2Val = analogRead(distPin2);

  // Flex
  flexPin3Val = analogRead(flexPin3);
  flexPin4Val = analogRead(flexPin4);
  flexPin5Val = analogRead(flexPin5);
  flexPin6Val = analogRead(flexPin6);

  // Photo
  photoPin7Val = analogRead(photoPin7);
  photoPin8Val = analogRead(photoPin8);
  photoPin9Val = analogRead(photoPin9);
  photoPin10Val = analogRead(photoPin10);

  // Serial print
  Serial.print(distPin0Val);
  Serial.print("\t");

  Serial.print(distPin1Val);
  Serial.print("\t");

  Serial.print(distPin2Val);
  Serial.print("\t");

  Serial.print(flexPin3Val);
  Serial.print("\t");

  Serial.print(flexPin4Val);
  Serial.print("\t");

  Serial.print(flexPin5Val);
  Serial.print("\t");

  Serial.print(flexPin6Val);
  Serial.print("\t");

  Serial.print(photoPin7Val);
  Serial.print("\t");

  Serial.print(photoPin8Val);
  Serial.print("\t");

  Serial.print(photoPin9Val);
  Serial.print("\t");

  Serial.println(photoPin10Val);

  delay(500);
}
