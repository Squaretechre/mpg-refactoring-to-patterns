#ifndef XMLBUILDER_H
#define XMLBUILDER_H

#include <string>

#include "IOutputBuilder.h"

class XmlBuilder : public IOutputBuilder
{
public:
  XmlBuilder(std::string root);
  void AddBelow(std::string tag) override;
  void AddAbove(std::string tag) override;
private:
  std::string Root;
};

#endif