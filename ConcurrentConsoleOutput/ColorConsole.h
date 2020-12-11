#pragma once

#include <iostream>
#include <unordered_map>

#include <Windows.h>

enum class ConsoleColor {
  Red = FOREGROUND_RED,
  Green = FOREGROUND_GREEN,
  Blue = FOREGROUND_BLUE,
  Yellow = Red | Green,
  Cyan = Blue | Green,
  Magenta = Red | Blue,
  LightRed = FOREGROUND_RED | FOREGROUND_INTENSITY,
  LightGreen = FOREGROUND_GREEN | FOREGROUND_INTENSITY,
  LightBlue = FOREGROUND_BLUE | FOREGROUND_INTENSITY,
  LightYellow = Yellow | FOREGROUND_INTENSITY,
  LightCyan = Cyan | FOREGROUND_INTENSITY,
  LightMagenta = Magenta | FOREGROUND_INTENSITY,
  Black = 0,
  White = Red | Green | Blue,
};

std::ostream& operator<<(std::ostream& os, const ConsoleColor& cc)
{
  HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
  SetConsoleTextAttribute(hConsole, static_cast<int>(cc));
  return os;
}

namespace std {
namespace {
  std::unordered_map<ConsoleColor, std::string> ConsoleColorNames{
    { ConsoleColor::Red, "Red" },
    { ConsoleColor::Green, "Green" },
    { ConsoleColor::Blue, "Blue" },
    { ConsoleColor::Yellow, "Yellow" },
    { ConsoleColor::Cyan, "Cyan" },
    { ConsoleColor::Magenta, "Magenta" },
    { ConsoleColor::LightRed, "LightRed" },
    { ConsoleColor::LightGreen, "LightGreen" },
    { ConsoleColor::LightBlue, "LightBlue" },
    { ConsoleColor::LightYellow, "LightYellow" },
    { ConsoleColor::LightCyan, "LightCyan" },
    { ConsoleColor::LightMagenta, "LightMagenta" },
    { ConsoleColor::White, "White" },
  };
}
const std::string& to_string(const ConsoleColor& cc)
{
  return ConsoleColorNames[cc];
}
}// namespace std