#ifndef DOMBUILDER_H
#define DOMBUILDER_H

#include <string>

#include "IOutputBuilder.h"

class DomBuilder : public IOutputBuilder
{
public:
  DomBuilder(std::string root);
  void AddBelow(std::string tag) override;
  void AddAbove(std::string tag) override;
private:
  std::string Root;
};

#endif