#include "ColorConsole.h"
#include "Constants.h"

#include <chrono>
#include <iomanip>
#include <iostream>
#include <mutex>
#include <thread>
#include <vector>

#undef USE_MUTEX
std::mutex mutex;

void OutputColoredText(ConsoleColor color)
{
    for (auto i = 0; i < IterationsPerThread; i++)
    {
        std::this_thread::sleep_for(std::chrono::milliseconds(10));
#ifdef USE_MUTEX
        std::lock_guard lock(mutex);
#endif
        std::cout << color << "Thread-ID: " << std::setfill('0') << std::setw(5)
                  << std::this_thread::get_id() << " is writing "
                  << std::to_string(color) << " to the console\n";
    }
}

int main()
{
    std::vector<std::thread> Threads;
    for (auto color : ConsoleColors)
    {
        Threads.emplace_back(OutputColoredText, color);
    }

    for (auto& thread : Threads)
    {
        thread.join();
    }
}