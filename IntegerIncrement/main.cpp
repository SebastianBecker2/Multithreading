#include <iostream>
#include <chrono>
#include <iomanip>
#include <mutex>
#include <thread>
#include <vector>
#include <atomic>

#undef USE_ATOMIC
#ifndef USE_ATOMIC
static int SharedCounter = 0;
#else
static std::atomic<int> SharedCounter = 0;
#endif

static constexpr int ThreadCount = 10;
static constexpr int IterationsPerThread = 100;
static constexpr std::chrono::milliseconds SleepPerIteration{ 10 };

void IncrementCounter() {
  for (auto i = 0; i < IterationsPerThread; i++)
  {
    std::this_thread::sleep_for(std::chrono::milliseconds(10));
    SharedCounter++;
  }
}

int main()
{
  std::vector<std::thread> Threads;
  for (auto i = 0; i < ThreadCount; i++)
  {
    Threads.emplace_back(IncrementCounter);
  }

  for (auto& thread : Threads)
  {
    thread.join();
  }

  std::cout << "SharedCounter: " << SharedCounter;
}