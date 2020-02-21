#ifndef IOUTPUTBUILDER_H
#define IOUTPUTBUILDER_H

#include <string>

class IOutputBuilder
{
public:
  virtual ~IOutputBuilder() {};
  virtual void AddBelow(std::string tag) = 0;
  virtual void AddAbove(std::string tag) = 0;
};

#endif