#pragma once

#include <chrono>
#include <vector>

#include "ColorConsole.h"

static constexpr int IterationsPerThread{ 5 };
static constexpr std::chrono::milliseconds SleepPerIteration{ 10 };
static std::vector<ConsoleColor> ConsoleColors{
  ConsoleColor::Red,
  ConsoleColor::Green,
  ConsoleColor::Blue,
  ConsoleColor::Yellow,
  ConsoleColor::Cyan,
  ConsoleColor::Magenta,
  ConsoleColor::LightRed,
  ConsoleColor::LightGreen,
  ConsoleColor::LightBlue,
  ConsoleColor::LightYellow,
  ConsoleColor::LightCyan,
  ConsoleColor::LightMagenta,
  ConsoleColor::White,
};