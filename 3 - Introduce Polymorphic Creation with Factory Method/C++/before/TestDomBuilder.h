#ifndef TESTDOMBUILDER_H
#define TESTDOMBUILDER_H

#include <gtest/gtest.h>

#include "DomBuilder.h"

class TestDomBuilder : public testing::Test
{
public:
  void TestAddAboveRoot();
private:
  std::unique_ptr<DomBuilder> Builder;
};

#endif