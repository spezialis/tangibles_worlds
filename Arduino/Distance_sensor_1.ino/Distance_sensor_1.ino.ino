#include <Wire.h>
#include "Adafruit_VL6180X.h"

Adafruit_VL6180X vl = Adafruit_VL6180X();

void setup() {
  Serial.begin(115200);

  // wait for serial port to open on native usb devices
  while (!Serial) {
    delay(1);
  }
  
  if (! vl.begin()) {
    Serial.println("Failed to find sensor");
    while (1);
  }
//  Serial.println("Sensor found!");
}

void loop() {
  uint8_t range = vl.readRange();
  Serial.println(range);

  delay(50);
  }
